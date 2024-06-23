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

namespace TableFromCodeWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = CreateWindowContent();
    }

    private object CreateWindowContent()
    {
        var cell11 = new TableCell(new Paragraph(new Run("Логические операторы"))) 
        {
            ColumnSpan = 5,
            FontSize = 20
        };

        var row1 = new TableRow();
        row1.Cells.Add(cell11);

        var cellA = new TableCell(new Paragraph(new Run("A")));
        var cellB = new TableCell(new Paragraph(new Run("B")));
        var cellAandB = new TableCell(new Paragraph(new Run("A && B")));
        var cellAorB = new TableCell(new Paragraph(new Run("A || B")));
        var cellNotA = new TableCell(new Paragraph(new Run("!A")));

        var row2 = new TableRow();
        row2.Cells.Add(cellA);
        row2.Cells.Add(cellB);
        row2.Cells.Add(cellAandB);
        row2.Cells.Add(cellAorB);
        row2.Cells.Add(cellNotA);
       
        var rowGroup1 = new TableRowGroup()
        {
            Background = Brushes.Wheat,
            FontWeight = FontWeights.Bold
        };
        rowGroup1.Rows.Add(row1);
        rowGroup1.Rows.Add(row2);


        var cell31 = new TableCell(new Paragraph(new Run("0")));
        var cell32 = new TableCell(new Paragraph(new Run("0")));
        var cell33 = new TableCell(new Paragraph(new Run("0")));
        var cell34 = new TableCell(new Paragraph(new Run("0")));
        var cell35 = new TableCell(new Paragraph(new Run("1")));

        var row3 = new TableRow();
        row3.Cells.Add(cell31);
        row3.Cells.Add(cell32);
        row3.Cells.Add(cell33);
        row3.Cells.Add(cell34);
        row3.Cells.Add(cell35);

        var cell41 = new TableCell(new Paragraph(new Run("0")));
        var cell42 = new TableCell(new Paragraph(new Run("1")));
        var cell43 = new TableCell(new Paragraph(new Run("0")));
        var cell44 = new TableCell(new Paragraph(new Run("1")));
        var cell45 = new TableCell(new Paragraph(new Run("1")));

        var row4 = new TableRow();
        row4.Cells.Add(cell41);
        row4.Cells.Add(cell42);
        row4.Cells.Add(cell43);
        row4.Cells.Add(cell44);
        row4.Cells.Add(cell45);

        var cell51 = new TableCell(new Paragraph(new Run("1")));
        var cell52 = new TableCell(new Paragraph(new Run("0")));
        var cell53 = new TableCell(new Paragraph(new Run("0")));
        var cell54 = new TableCell(new Paragraph(new Run("1")));
        var cell55 = new TableCell(new Paragraph(new Run("0")));

        var row5 = new TableRow();
        row5.Cells.Add(cell51);
        row5.Cells.Add(cell52);
        row5.Cells.Add(cell53);
        row5.Cells.Add(cell54);
        row5.Cells.Add(cell55);

        var cell61 = new TableCell(new Paragraph(new Run("1")));
        var cell62 = new TableCell(new Paragraph(new Run("1")));
        var cell63 = new TableCell(new Paragraph(new Run("1")));
        var cell64 = new TableCell(new Paragraph(new Run("1")));
        var cell65 = new TableCell(new Paragraph(new Run("0")));

        var row6 = new TableRow();
        row6.Cells.Add(cell61);
        row6.Cells.Add(cell62);
        row6.Cells.Add(cell63);
        row6.Cells.Add(cell64);
        row6.Cells.Add(cell65);


        var rowGroup2 = new TableRowGroup()
        {
            Background = Brushes.AliceBlue,
            FontFamily = new FontFamily("Consolas"),
            Foreground = Brushes.Blue
        };
        rowGroup2.Rows.Add(row3);
        rowGroup2.Rows.Add(row4);
        rowGroup2.Rows.Add(row5);
        rowGroup2.Rows.Add(row6);

        var table = new Table
        {
            TextAlignment = TextAlignment.Center
        };
        table.RowGroups.Add(rowGroup1);
        table.RowGroups.Add(rowGroup2);

        var document = new FlowDocument();
        document.Blocks.Add(table);
        return document;
    }
}
