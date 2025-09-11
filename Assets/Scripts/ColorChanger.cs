using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Header("���� ���� ����� �������")]
    [SerializeField] private Color _droppedColor = Color.gray;
    [Header("���� ���� � �����")]
    [SerializeField] private Color _rainColor = Color.blue;

    public void Drop(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = _droppedColor;
    }

    public void Rain(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = _rainColor;
    }
}
