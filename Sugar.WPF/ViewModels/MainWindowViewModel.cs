using Caliburn.Micro;
using JOJO.UC;
using Panuon.UI;
using Panuon.UIBrowser.ViewModels.Partial;
using Sugar.WPF.Areas.System.Models;
using Sugar.WPF.Utils;
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

    public class MainWindowViewModel : Conductor<IShell>.Collection.OneActive, IShell
    {
        List<PUTabItemModel> tablist = new List<PUTabItemModel>() ;
        PUTabItemModel defaultTabItem = new PUTabItemModel() {Header ="系统首页" };
        public MainWindowViewModel()
        {
            TreeViewItems = new ObservableCollection<PUTreeViewItemModel>();
            LoadTreeView();
            LoadTabControlsView(defaultTabItem);
            //ActivateItem(new TabControlsViewModel());
        }

        public void LoadTabControlsView(PUTabItemModel model)
        {
            if (!tablist.Exists(r=>r.Header==model.Header))
            {
                tablist.Add(model);
                TabItemList = new BindableCollection<PUTabItemModel>(tablist);
            }
           
            
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
                object ect = Assembly.LoadFile($@"{Environment.CurrentDirectory}\\JOJO.UC.dll").CreateInstance(fullName, true, BindingFlags.Default, null, parameters, null, null);
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
            var model = CreateInstance<IShell>("JOJO.UC.ViewModels", "IndexViewModel", null);
            //var model= CreateInstance<IShell>("Panuon.UIBrowser.ViewModels.Partial", "TreeViewsViewModel", null);
            ActivateItem(model);
        }
        public void ChoosedItemChanged(RoutedPropertyChangedEventArgs<PUTreeViewItem> e)
        {
            
            var choosedItem = e.NewValue;
            ChangeSelect(choosedItem.Value.ToString().Split('/')[1]);
            if (choosedItem != null)
                ChoosedHeader = choosedItem.Header;
        }
        #endregion

        #region Function
        public void LoadTreeView()
        {
            var response = new Ajax<List<Menus>, Default>()
            {
                url = @"http://localhost:17924/Home/GetLeftMenu",
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
