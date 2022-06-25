using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataGridPerfTest2;

public partial class MainWindow : Window
{
	private StackPanel? _stackPanel;
	private DataGrid? _dataGrid;
	private readonly List<TestItem> _list = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);

		//Width = 2800; // 10x speed improvement hardcoding Width

		for (int i = 0; i < 100; i++)
		{
			_list.Add(new TestItem());
		}

		Button button = new()
		{
			Content = "Toggle"
		};
		button.Click += Button_Click;

		_stackPanel = new();
		_stackPanel.Children.Add(button);

		Content = _stackPanel;
	}

	private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		Debug.WriteLine($"Width={Bounds.Width}");

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
			};
			_stackPanel!.Children.Add(_dataGrid);

			watch.Stop();
			Debug.WriteLine($"DataGrid added, [ time = {watch.ElapsedMilliseconds}ms ]");
		}
		else
		{
			// These will also all trigger the slowdown
			//_dataGrid.IsVisible = false;
			//Debug.WriteLine($"_dataGrid.IsVisible = false, [ time = { watch.ElapsedMilliseconds}ms ]");
			//_dataGrid.Columns.Clear();
			//_dataGrid.Items = null; // 9400 ms
			//Debug.WriteLine($"_dataGrid.Items = null, [ time = { watch.ElapsedMilliseconds}ms ]");

			_stackPanel!.Children.Remove(_dataGrid);
			_dataGrid = null;

			watch.Stop();
			Debug.WriteLine($"DataGrid removed, [ time = {watch.ElapsedMilliseconds}ms ]");
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
