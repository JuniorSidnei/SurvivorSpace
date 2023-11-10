using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SurvivorSpace.Grid {
    
    public class Grid {
        private int _width;
        private int _height;
        private float _cellSize;
        private Vector3 _originPosition;
        private int[,] _gridArray;
        private Dictionary<KeyValuePair<int, int>, GameObject> _textList;
        private GameObject _textVisualizer;
        
        public Grid(int width, int height, float cellSize, Vector3 originPosition) {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _originPosition = originPosition;

            _gridArray = new int[_width, _height];
            _textList = new Dictionary<KeyValuePair<int, int>, GameObject>();
            
            _textVisualizer = Resources.Load("Prefabs/UI/CellTextPositionVisualizer") as GameObject;
            
            
            for (int y = 0; y < _gridArray.GetLength(1); y++) {
                for (int x = 0; x < _gridArray.GetLength(0); x++) {
                    var textObj = Object.Instantiate(_textVisualizer, null);
                    textObj.transform.position = GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f;
                    var canvas = textObj.transform.GetChild(0);
                    var text = canvas.GetChild(0).GetComponent<TextMeshProUGUI>();
                    text.text = $"{x},{y}";
                    _textList.Add(new KeyValuePair<int, int>(x, y), textObj);
                    
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y+1), Color.magenta, 100f);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1, y), Color.magenta, 100f);
                }
            }
            
            
            Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.magenta, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width, height), Color.magenta, 100f);
        }

        public void SetValueInCell(int x, int y, int value) {
            if (x >= 0 && y >= 0 && x < _width && y < _height) {
                _gridArray[x, y] = value;
                var newValue = _gridArray[x, y].ToString();
                var textObj = _textList[new KeyValuePair<int, int>(x,y)];
                var canvas = textObj.transform.GetChild(0);
                var text = canvas.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = newValue;
            }
        }

        public void SetValue(Vector3 worldPosition, int value) {
            var gridPosition = GetGridPosition(worldPosition);
            SetValueInCell(gridPosition.x, gridPosition.y, value);
        }
        
        private Vector3 GetWorldPosition(int x, int y) {
            return new Vector3(x, y) * _cellSize + _originPosition;
        }

        private Vector2Int GetGridPosition(Vector3 worldPosition) {
            var x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
            var y = Mathf.FloorToInt((worldPosition - _originPosition).y / _cellSize);
            return new Vector2Int(x, y);
        }
    }
}