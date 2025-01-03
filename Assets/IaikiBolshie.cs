using UnityEngine;

public class IaikiBolshie : MonoBehaviour
{
    public GameObject player; // Ссылка на игрока
    public Transform Point; // Точка, куда будет перемещён игрок

    private Vector3 previousPlayerPosition; // Предыдущая позиция игрока
    private Vector3 previousCameraPosition; // Предыдущая позиция камеры

    private bool hasMoved = false; // Переменная для отслеживания, было ли перемещение

    void Start()
    {
        // Сохраняем начальные позиции
        SaveCurrentPositions();
    }

    void Update()
    {
        // Проверяем нажатие клавиши E и если еще не перемещали игрока
        if (Input.GetKeyDown(KeyCode.E) && !hasMoved)
        {
            // Проверяем, попал ли луч в объект
            if (RayCastGloabl.rayGlobal.collider.name == gameObject.name)
            {
                // Сохраняем текущие позиции перед перемещением
                SaveCurrentPositions();

                // Перемещаем камеру игрока к заданной точке
                MovePlayerToPoint();
                hasMoved = true; // Устанавливаем флаг, что игрок был перемещен
            }
        }
    }

    // Метод для сохранения текущих позиций игрока и камеры
    private void SaveCurrentPositions()
    {
        previousPlayerPosition = player.transform.position;
        previousCameraPosition = player.GetComponentInChildren<Camera>().transform.position;
    }

    // Метод для перемещения игрока к заданной точке
    private void MovePlayerToPoint()
    {
        LeanTween.move(player.GetComponentInChildren<Camera>().gameObject, Point.position, 1f);
        LeanTween.rotate(player.GetComponentInChildren<Camera>().gameObject, new Vector3(0, 0, 0), 1f);

        // Отключаем управление и отображение
        player.GetComponentInChildren<FirstPersonLook>().enabled = false;
        player.GetComponentInChildren<MeshRenderer>().enabled = false;
        player.GetComponent<FirstPersonMovement>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<MeshCollider>().enabled = false;

        // Управляем курсором
        Screen.lockCursor = false;
        Cursor.visible = true;
    }

    // Метод для возврата игрока на предыдущие позиции
    public void ReturnToPreviousPosition()
    {
        player.GetComponentInChildren<Camera>().transform.localPosition = new Vector3(0f, 1.48800004f, 0f);

        // Включаем управление и отображение
        player.GetComponentInChildren<FirstPersonLook>().enabled = true;
        player.GetComponentInChildren<MeshRenderer>().enabled = true;
        player.GetComponent<FirstPersonMovement>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<MeshCollider>().enabled = true;

        // Управляем курсором
        Screen.lockCursor = true;
        Cursor.visible = false;
    }
}
