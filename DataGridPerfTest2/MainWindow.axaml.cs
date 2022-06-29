using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataGridPerfTest2;

public partial class MainWindow : Window
{
	private Grid? _grid;
	private DataGrid? _dataGrid;
	private TreeDataGrid? _treeDataGrid;
	private readonly List<TestItem> _list = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);

		for (int i = 0; i < 100; i++)
		{
			_list.Add(new TestItem());
		}

		Button dataGridButton = new()
		{
			Content = "Toggle DataGrid"
		};
		dataGridButton.Click += DataGridButton_Click;

		Button treeDataGridButton = new()
		{
			Content = "Toggle TreeDataGrid",
			[Grid.RowProperty] = 1,
		};
		treeDataGridButton.Click += TreeDataGridButton_Click;

		_grid = new();
		_grid.RowDefinitions = new RowDefinitions("auto,auto,*");
		_grid.ColumnDefinitions = new ColumnDefinitions("*");
		_grid.Children.Add(dataGridButton);
		_grid.Children.Add(treeDataGridButton);

		Content = _grid;
	}

	private void DataGridButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		//Debug.WriteLine($"Width={Bounds.Width}");

		var watch = Stopwatch.StartNew();

		if (_dataGrid == null)
		{
			_dataGrid = new DataGrid()
			{
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				Background = Brushes.White,
				RowBackground = Brushes.White,
				AlternatingRowBackground = Brushes.White,
				Items = new DataGridCollectionView(_list),
				AutoGenerateColumns = true,
				[Grid.RowProperty] = 2,
			};
			_grid!.Children.Add(_dataGrid);

			watch.Stop();
			Debug.WriteLine($"DataGrid added, [ time = {watch.ElapsedMilliseconds}ms ]");
		}
		else
		{
			//BeginBatchUpdate();
			//_dataGrid.Width = 1;
			//_dataGrid.Height = 1;

			//_dataGrid.IsVisible = false;
			//Debug.WriteLine($"_dataGrid.IsVisible = false, [ time = { watch.ElapsedMilliseconds}ms ]");

			// These will also all trigger the slowdown
			//_dataGrid.Columns.Clear();
			//Debug.WriteLine($"_dataGrid.Columns.Clear(), [ time = {watch.ElapsedMilliseconds}ms ]");
			//_dataGrid.Items = null; // 9400 ms
			//Debug.WriteLine($"_dataGrid.Items = null, [ time = { watch.ElapsedMilliseconds}ms ]");

			_grid!.Children.Remove(_dataGrid);
			//EndBatchUpdate();
			_dataGrid = null;

			watch.Stop();
			Debug.WriteLine($"DataGrid removed, [ time = {watch.ElapsedMilliseconds}ms ]");
		}
	}

	private void TreeDataGridButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		//Debug.WriteLine($"Width={Bounds.Width}");

		var watch = Stopwatch.StartNew();

		if (_treeDataGrid == null)
		{
			_treeDataGrid = new TreeDataGrid()
			{
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				Background = Brushes.White,
				Source = new FlatTreeDataGridSource<TestItem>(_list)
				{
					Columns =
					{
						new TextColumn<TestItem, int>("Index", x => x.Index),
						new TextColumn<TestItem, int>("Num 0", x => x.Num0),
						new TextColumn<TestItem, int>("Num 1", x => x.Num1),
						new TextColumn<TestItem, int>("Num 2", x => x.Num2),
						new TextColumn<TestItem, int>("Num 3", x => x.Num3),
						new TextColumn<TestItem, int>("Num 4", x => x.Num4),
						new TextColumn<TestItem, int>("Num 5", x => x.Num5),
						new TextColumn<TestItem, int>("Num 6", x => x.Num6),
						new TextColumn<TestItem, int>("Num 7", x => x.Num7),
						new TextColumn<TestItem, int>("Num 8", x => x.Num8),
						new TextColumn<TestItem, int>("Num 9", x => x.Num9),
						new TextColumn<TestItem, int>("Num 10", x => x.Num10),
						new TextColumn<TestItem, int>("Num 11", x => x.Num11),
						new TextColumn<TestItem, int>("Num 12", x => x.Num12),
						new TextColumn<TestItem, int>("Num 13", x => x.Num13),
						new TextColumn<TestItem, int>("Num 14", x => x.Num14),
						new TextColumn<TestItem, int>("Num 15", x => x.Num15),
						new TextColumn<TestItem, int>("Num 16", x => x.Num16),
						new TextColumn<TestItem, int>("Num 17", x => x.Num17),
						new TextColumn<TestItem, int>("Num 18", x => x.Num18),
						new TextColumn<TestItem, int>("Num 19", x => x.Num19),
					},
				},
				[Grid.RowProperty] = 2,
			};
			_grid!.Children.Add(_treeDataGrid);

			watch.Stop();
			Debug.WriteLine($"TreeDataGrid added, [ time = {watch.ElapsedMilliseconds}ms ]");
		}
		else
		{
			_grid!.Children.Remove(_treeDataGrid);
			_treeDataGrid = null;

			watch.Stop();
			Debug.WriteLine($"TreeDataGrid removed, [ time = {watch.ElapsedMilliseconds}ms ]");
		}
	}

	public class TestItem
	{
		public int Index { get; set; } = 0;
		public int Num0 { get; set; } = 0;
		public int Num1 { get; set; } = 0;
		public int Num2 { get; set; } = 0;
		public int Num3 { get; set; } = 0;
		public int Num4 { get; set; } = 0;
		public int Num5 { get; set; } = 0;
		public int Num6 { get; set; } = 0;
		public int Num7 { get; set; } = 0;
		public int Num8 { get; set; } = 0;
		public int Num9 { get; set; } = 0;
		public int Num10 { get; set; } = 0;
		public int Num11 { get; set; } = 0;
		public int Num12 { get; set; } = 0;
		public int Num13 { get; set; } = 0;
		public int Num14 { get; set; } = 0;
		public int Num15 { get; set; } = 0;
		public int Num16 { get; set; } = 0;
		public int Num17 { get; set; } = 0;
		public int Num18 { get; set; } = 0;
		public int Num19 { get; set; } = 0;

		public override string ToString() => Index.ToString();
	}
}
