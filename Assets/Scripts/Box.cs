using System;
using UnityEngine;

public class Box : SingletonMonoBehaviour<Box>
{
    #region Variables

    private Transform _cachedTransform;

    #endregion


    #region Properties

    public Vector3 PadStartPosition { get; private set; }

    #endregion

    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        _cachedTransform = transform;
        PadStartPosition = _cachedTransform.position;
    }

    private void Update()
    {
        MoveWithMouse();
    }

    #endregion


    #region Private methods

    private void MoveWithMouse()
    {
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        Vector3 currentPosition = _cachedTransform.position;
        currentPosition.x = mousePositionInUnits.x;

        _cachedTransform.position = currentPosition;
    }

    #endregion


    
}