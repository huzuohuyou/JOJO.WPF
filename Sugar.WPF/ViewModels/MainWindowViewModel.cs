using Caliburn.Metro.Demo.ViewModels.Flyouts;
using Caliburn.Micro;
using Elight.Infrastructure;
using JOJO.UC;
using JOJO.ViewModels;
using MahApps.Metro.Controls;
using Panuon.UI;
using Panuon.UIBrowser.ViewModels.Partial;
using Sugar.WPF.Areas.System.Models;
using Sugar.WPF.Utils;
using Sugar.WPF.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Sugar.WPF.ViewModels
{
    [Export(typeof(IShell))]
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Conductor<IShell>.Collection.OneActive, IShell
    {
        
        List<PUTabItemModel> tablist = new List<PUTabItemModel>() ;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public MainWindowViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var viewModel = IoC.Get<LoginViewModel>();
           
            var ok = windowManager.ShowDialog(viewModel);
            if (ok.HasValue && ok.Value)
            {
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                TreeViewItems = new ObservableCollection<PUTreeViewItemModel>();
                LoadTreeView(viewModel.Login());
                LoadTabControlsView(new List<IShell> {
                        new IndexViewModel() { },
                        new TreeViewsViewModel(),
                        new Flyout1ViewModel() });
            }


           
        }



        private void MetroTabControl_TabItemClosingEvent(object sender, BaseMetroTabControl.TabItemClosingEventArgs e)
        {
            if (e.ClosingTabItem.Header.ToString().StartsWith("sizes"))
                e.Cancel = true;
        }
        public void LoadTabControlsView(IEnumerable<IShell> tabs)
        {
            Items.AddRange(tabs);
        }

        public BindableCollection<PUTabItemModel> TabItemList
        {
            get { return _tabItemList; }
            set { _tabItemList = value; NotifyOfPropertyChange(() => TabItemList); }
        }
        private BindableCollection<PUTabItemModel> _tabItemList;

        #region Binding
        public ObservableCollection<PUTreeViewItemModel> TreeViewItems
        {
            get { return _treeViewItems; }
            set { _treeViewItems = value; NotifyOfPropertyChange(() => TreeViewItems); }
        }
        private ObservableCollection<PUTreeViewItemModel> _treeViewItems;

        public object ChoosedHeader
        {
            get { return _choosedHeader; }
            set { _choosedHeader = value; NotifyOfPropertyChange(() => ChoosedHeader); }
        }
        private object _choosedHeader;

        public object ChoosedValue
        {
            get { return _choosedValue; }
            set { _choosedValue = value; NotifyOfPropertyChange(() => ChoosedValue); }
        }
        private object _choosedValue;
        #endregion

        #region Event

        public static T CreateInstance<T>(string nameSpace, string className, object[] parameters)
        {
            try
            {
                //命名空间.类型名
                string fullName = nameSpace + "." + className;
                //加载程序集，创建程序集里面的 命名空间.类型名 实例
                object ect = Assembly.LoadFrom($@"{Environment.CurrentDirectory}\JOJO.ViewModels.dll").CreateInstance(fullName);
                //类型转换并返回
                return (T)ect;
            }
            catch (Exception ex)
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }


        public void ChangeSelect(string select)
        {
            try
            {
                var model = CreateInstance<IShell>("JOJO.ViewModels", $"{select}ViewModel", null);
                var isNewTab = true;
                Items.ToList().ForEach(r => {
                    if (r.GetType() == model.GetType())
                    {
                        isNewTab = false;
                        ActivateItem(r);
                    }
                });
                if (isNewTab)
                {
                    ActivateItem(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        public void ChoosedItemChanged(RoutedPropertyChangedEventArgs<PUTreeViewItem> e)
        {
            var choosedItem = e.NewValue;
            ChangeSelect(choosedItem.Value.ToString().Split('/')[2]);
            if (choosedItem != null)
                ChoosedHeader = choosedItem.Header;
        }
        #endregion

        #region Function
        public void LoadTreeView(Operator ope)
        {
            var response = new Ajax<List<Menus>, Operator>(ope)
            {
                url = @"http://localhost:17924/Home/GetLeftMenu2",
            }.Post();
            
            response.ForEach(r =>
            {
                TreeViewItems.Add(new PUTreeViewItemModel()
                {
                    Header = r.title,
                    Value = string.Empty,
                    Items = (from i in r.children select new PUTreeViewItemModel { Header = i.title, Value = i.href }).ToList(),
                });
            });

            // NotifyOfPropertyChange(() => TreeViewItems);
        }
        #endregion

    }
}
