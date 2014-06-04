using System;
using System.ComponentModel;
using System.Windows.Controls;
using Model;

namespace DonkeyWPF.Filter
{
    public class TextSearchFilter
    {
        public TextSearchFilter(ICollectionView filteredView, TextBox textBox)
        {
            var filterText = string.Empty;

            filteredView.Filter = obj =>
            {
                if (String.IsNullOrEmpty(filterText))
                    return true;

                var o = obj as Server;

                if (o == null) return false;

                var str = o.Name; //as string;
                if (String.IsNullOrEmpty(str))
                    return false;

                var index = str.IndexOf(
                    filterText,
                    0,
                    StringComparison.InvariantCultureIgnoreCase);

                return index > -1;
            };

            textBox.TextChanged += (sender, args) =>
            {
                filterText = textBox.Text;
                filteredView.Refresh();
            };
        }
    }
}
