using System;
using System.Collections;
using System.Collections.Generic;
using SurvivorSpace.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using Grid = SurvivorSpace.Grid.Grid;

public class TestGrid : MonoBehaviour {

    public MouseWorldPosition MouseWorldPosition;
    
    private Grid _grid;
    
    private void Start() {
        _grid = new Grid(4, 2, 1f, new Vector3(30f, 0f));
    }

    private void Update() {
        if (Mouse.current.leftButton.isPressed) {
            _grid.SetValue(MouseWorldPosition.CurrentPosition, 69);
        }
    }
}
