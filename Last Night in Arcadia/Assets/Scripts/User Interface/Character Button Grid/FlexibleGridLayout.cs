using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    private enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }


    [Header("Grid Sizing")]
    [SerializeField] private FitType _fitType;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private Vector2 _spacing;

    [Header("Cell Sizing")]
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private bool _fitX;
    [SerializeField] private bool _fitY;


    /// <summary>
    /// Displays all elements in a grid layout.
    /// </summary>
    public override void CalculateLayoutInputHorizontal()
    {
        // Sets up the Grid from the base GridLayout. Necessary!
        base.CalculateLayoutInputHorizontal();

        CalculateRowsAndColumns();
        CalculateCellSize();
        SetGridElementsPositions();
    }


    /// <summary>
    /// Calculates the number of rows and columns needed based off the fit type.
    /// </summary>
    private void CalculateRowsAndColumns()
    {
        int numElements = this.transform.childCount;

        if (_fitType == FitType.Uniform || _fitType == FitType.Width ||  _fitType == FitType.Height)
        {
            float sqrt = Mathf.Sqrt(numElements);
            _rows = Mathf.CeilToInt(sqrt);
            _columns = Mathf.CeilToInt(sqrt);
        }

        if (_fitType == FitType.Width || _fitType == FitType.FixedColumns)
        {
            _rows = Mathf.CeilToInt(numElements / (float)_columns);
        }
        else if (_fitType == FitType.Height || _fitType == FitType.FixedRows)
        {
            _columns = Mathf.CeilToInt(numElements / (float)_rows);
        }
    }


    /// <summary>
    /// Calculates the cell size based off the number of rows/columns, spacing, and padding.
    /// </summary>
    private void CalculateCellSize()
    {
        float defaultWidth = rectTransform.rect.width / (float)_columns;
        float defaultHeight = rectTransform.rect.height / (float)_rows;

        float widthSpacing = (_spacing.x / (float)_columns) * (_columns - 1);
        float heightSpacing = (_spacing.y / (float)_rows) * (_rows - 1);

        float widthPadding = (padding.left / (float)_columns) - (padding.right / (float)_columns);
        float heightPadding = (padding.top / (float)_rows) - (padding.bottom / (float)_rows);

        float cellWidth = defaultWidth - widthSpacing - widthPadding;
        float cellHeight = defaultHeight - heightSpacing - heightPadding;

        _cellSize.x = _fitX ? cellWidth : _cellSize.x;
        _cellSize.y = _fitY ? cellHeight : _cellSize.y;
    }


    /// <summary>
    /// Set grid element positions based off the number of rows/columns, spacing, and padding.
    /// </summary>
    private void SetGridElementsPositions()
    {
        int rowIndex = 0;
        int columnIndex = 0;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            rowIndex = i / _columns;
            columnIndex = i % _columns;

            RectTransform gridElement = rectChildren[i];

            float xSpacing = _spacing.x * columnIndex;
            float ySpacing = _spacing.y * rowIndex;

            float xPos = (_cellSize.x * columnIndex) + xSpacing + padding.left;
            float yPos = (_cellSize.y * rowIndex) + ySpacing + padding.top;

            SetChildAlongAxis(gridElement, 0, xPos, _cellSize.x);
            SetChildAlongAxis(gridElement, 1, yPos, _cellSize.y);
        }
    }


    /// <summary>
    /// Function needs to be declared from abstract base class, but not used in our implementation.
    /// </summary>
    public override void CalculateLayoutInputVertical()
    {
        return;
    }


    /// <summary>
    /// Function needs to be declared from abstract base class, but not used in our implementation.
    /// </summary>
    public override void SetLayoutHorizontal()
    {
        return;
    }


    /// <summary>
    /// Function needs to be declared from abstract base class, but not used in our implementation.
    /// </summary>
    public override void SetLayoutVertical()
    {
        return;
    }
}
