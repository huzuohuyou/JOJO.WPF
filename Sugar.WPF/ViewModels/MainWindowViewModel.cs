using Caliburn.Micro;
using Panuon.UI;
using Panuon.UIBrowser.ViewModels.Partial;
using Sugar.WPF.Areas.System.Models;
using Sugar.WPF.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;

namespace Sugar.WPF.ViewModels
{
    [Export(typeof(IShell))]

    public class MainWindowViewModel : Conductor<IShell>.Collection.OneActive, IShell
    {
        public MainWindowViewModel()
        {
            TreeViewItems = new ObservableCollection<PUTreeViewItemModel>();
            LoadTreeView();
            //ActivateItem(new TreeViewsViewModel());
        }


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
        public void ChoosedItemChanged(RoutedPropertyChangedEventArgs<PUTreeViewItem> e)
        {
            var choosedItem = e.NewValue;
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
