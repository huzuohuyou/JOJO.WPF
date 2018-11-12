using Caliburn.Metro.Demo.ViewModels.Flyouts;
using Caliburn.Micro;
using JOJO.UC;
using JOJO.UserControls;
using Panuon.UI;
using Panuon.UIBrowser.ViewModels.Partial;
using Sugar.WPF.Areas.System.Models;
using Sugar.WPF.Areas.System.ViewModels;
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
        static IndexViewModel indexvm = new IndexViewModel();
        public MainWindowViewModel()
        {
            TreeViewItems = new ObservableCollection<PUTreeViewItemModel>();
            LoadTreeView();
            LoadTabControlsView(new List<IShell> { new IndexViewModel() {
                
            },new TreeViewsViewModel(),new Flyout1ViewModel() });
            //ActivateItem(new TabControlsViewModel());
        }

        //public MainWindowViewModel(IEnumerable<IShell> tabs)
        //{
        //    TreeViewItems = new ObservableCollection<PUTreeViewItemModel>();
        //    LoadTreeView();
        //    Items.AddRange(tabs);
        //}

        public void LoadTabControlsView(IEnumerable<IShell> tabs)
        {
            Items.AddRange(tabs);
            //if (!tablist.Exists(r => r.Header == model.Header))
            //{
            //    tablist.Add(model);
            //    TabItemList = new BindableCollection<PUTabItemModel>(tablist);
            //}

            //var d = new UserControlView();
            //var temp = tabs.ToList()[0] as PUTabItemModel;
            //var uc = new UserControlView();
            //temp.Content = uc;
            //var list = new List<PUTabItemModel>();
            //list.Add(temp);

            //list.Add(new PUTabItemModel()
            //{
            //    Header = "Test1",
            //    Icon = "",
            //    CanDelete = false,
            //    Content = d,
            //    Value = 1.1,

                //});
                //list.Add(new ButtonsViewModel()
                //{
                //    Header = "Test2",
                //    Icon = "",
                //    CanDelete = true,
                //    Content = "TreeViewsViewModel",
                //    Value = new PUTreeViewItemModel(),
                //});
                //list.Add(new PUTabItemModel()
                //{
                //    Header = "Test3",
                //    Icon = "",
                //    CanDelete = false,
                //    Content = "3",
                //    Value = 3.3,
                //});
                //TabItemList = new BindableCollection<PUTabItemModel>(list);

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
                

                object ect = Assembly.LoadFrom($@"{Environment.CurrentDirectory}\JOJO.UC.dll").CreateInstance(fullName);
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
