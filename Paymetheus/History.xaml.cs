using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paymetheus.ViewModels;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            InitializeComponent();
        }

        private bool sortTransactionsAsc = true;

        private void SetSortArrow(int gridCollumn)
        {
            sortTransactionsAsc = !sortTransactionsAsc;

            if(sortTransactionsAsc)
                SortArrow.Data = Geometry.Parse("M0,0 L1,0 0.5,1 z");
            else
                SortArrow.Data = Geometry.Parse("M0.5,1 L1,0.5 1.5,1 z");
            SortArrow.SetValue(Grid.ColumnProperty, gridCollumn);
        }

        private void TextBlockDate_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var transactionHistoryViewModel = (TransactionHistoryViewModel)ViewModelLocator.TransactionHistoryViewModel;
            transactionHistoryViewModel.SortTransactionsByDate(sortTransactionsAsc);
            SetSortArrow(0);
            SortArrow.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        }

        private void TextBlockHashCode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var transactionHistoryViewModel = (TransactionHistoryViewModel)ViewModelLocator.TransactionHistoryViewModel;
            transactionHistoryViewModel.SortTransactionsByHashCode(sortTransactionsAsc);
            SetSortArrow(1);
            SortArrow.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        }

        private void TextBlockDebitCredit(object sender, MouseButtonEventArgs e)
        {
            var transactionHistoryViewModel = (TransactionHistoryViewModel)ViewModelLocator.TransactionHistoryViewModel;
            transactionHistoryViewModel.SortTransactionsByDebitCredit(sortTransactionsAsc);
            SetSortArrow(2);
            SortArrow.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Left);
        }

        private void TextBlockBalance_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var transactionHistoryViewModel = (TransactionHistoryViewModel)ViewModelLocator.TransactionHistoryViewModel;
            transactionHistoryViewModel.SortTransactionsByBalance(sortTransactionsAsc);
            SetSortArrow(3);
            SortArrow.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Left);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortArrow == null)
                return;

            sortTransactionsAsc = false;
            SortArrow.Data = Geometry.Parse("M0,0 L1,0 0.5,1 z");
            SortArrow.SetValue(Grid.ColumnProperty, 0);
            SortArrow.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        }
    }
}
