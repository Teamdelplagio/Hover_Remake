using UnityEngine;

public class Movement : MonoBehaviour

{
    [SerializeField] private MovementSettings settings;
    // Update viene chiamato una volta per frame
    void Update()
    {
        // Ottieni gli input orizzontali e verticali (ad esempio W, A, S, D o frecce direzionali)
        float horizontal = Input.GetAxis("Horizontal"); // Asse X (sinistra/destra)
        float vertical = Input.GetAxis("Vertical"); // Asse Z (avanti/indietro)

        // Movimento del giocatore
        Vector3 movement = new Vector3(horizontal, 0, vertical) * settings.walkSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotazione del giocatore in base ai tasti di movimento
        if (movement.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, settings.rotationSpeed * Time.deltaTime);
        }
    }
}
