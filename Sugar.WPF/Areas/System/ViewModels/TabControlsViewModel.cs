using Caliburn.Micro;
using JOJO.UC;
using Panuon.UI;
using Sugar.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panuon.UIBrowser.ViewModels.Partial
{
    public class TabControlsViewModel : Screen, IShell
    {
        public TabControlsViewModel()
        {
            var list = new List<PUTabItemModel>();
            list.Add(new PUTabItemModel()
            {
                Header = "Test1",
                Icon = "",
                CanDelete = false,
                Content = "1",
                Value = 1.1,
            });
            list.Add(new ButtonsViewModel()
            {
                Header = "Test2",
                Icon= "",
                CanDelete = true,
                Content = "TreeViewsViewModel",
                Value = new PUTreeViewItemModel(),
            });
            list.Add(new PUTabItemModel()
            {
                Header = "Test3",
                Icon= "",
                CanDelete = false,
                Content = "3",
                Value = 3.3,
            });
            TabItemList = new BindableCollection<PUTabItemModel>(list);
        }

        public BindableCollection<PUTabItemModel> TabItemList
        {
            get { return _tabItemList; }
            set { _tabItemList = value; NotifyOfPropertyChange(() => TabItemList); }
        }
        private BindableCollection<PUTabItemModel> _tabItemList;


    }
}
