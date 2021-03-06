﻿using ANAConversationStudio.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ANAConversationStudio.Models.Chat.Sections
{
    public class GraphSection : Section
    {
        public ObservableCollection<Coordinates> CoordinatesSet { get; set; } = new ObservableCollection<Coordinates>();

        [ExpandableObject]
        public Axis X { get; set; } = new Axis();
        [ExpandableObject]
        public Axis Y { get; set; } = new Axis();
        public string Caption { get; set; }
        public GraphTypeEnum GraphType { get; set; }
        public GraphSection() { SectionType = SectionTypeEnum.Graph; }
    }

    public enum GraphTypeEnum
    {
        Bar, Line, ScatterPlot, Histogram
    }

    public class Axis : BaseEntity
    {
        public string Label { get; set; }

        public AxisTypeEnum AxisType
        {
            get; set;
        }
    }

    public enum AxisTypeEnum
    {
        [Description("Integer")]
        Integer,

        [Description("Double")]
        Double,

        [Description("String")]
        String,

        [Description("yyyy-MM-dd")]
        YearMonthDay,

        [Description("yyyy-MM")]
        YearMonth,

        [Description("yyyy-MonthName")]
        YearMonthName,

        [Description("yyyy-MM-dd hh:mm:ss")]
        YearMonthDayHourMinuteSecond,

        [Description("hh:mm:ss")]
        HourMinuteSecond,

        [Description("WeekDay")]
        WeekDay,

        [Description("yy")]
        Year,

        [Description("MM")]
        Month,

        [Description("MonthName")]
        MonthName,

        [Description("dd")]
        Day,

        [Description("DayName")]
        DayName,
    }

    public class Coordinates
    {
        public string CoordinateListId { get; set; }
        public List<Coordinate> CoordinateList { get; set; } = new List<Coordinate>();
        public string LegendName { get; set; }

        public void AddXYCoordinates(string x, string y)
        {
            if (CoordinateList == null)
                CoordinateList = new List<Coordinate>();

            CoordinateList.Add(new Coordinate(x, y));
        }

        public void AddXYCoordinates(string x, string y, string coordinateName)
        {
            if (CoordinateList == null)
                CoordinateList = new List<Coordinate>();

            CoordinateList.Add(new Coordinate(x, y, coordinateName));
        }
    }

    public class Coordinate
    {
        public Coordinate(string x, string y)
        {
            this.X = x;
            this.Y = y;
        }
        public Coordinate() { }
        public Coordinate(string x, string y, string coordinateText) : this(x, y)
        {
            this.CoordinateText = coordinateText;
        }

        public string X { get; set; }
        public string Y { get; set; }
        public string CoordinateText { get; set; }
    }
}