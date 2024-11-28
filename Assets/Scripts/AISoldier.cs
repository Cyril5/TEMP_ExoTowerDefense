using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AISoldier : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;
    UnityEvent<AISoldier> OnSpawn; // Utilisez Invoke(this) pour appeler l'evenement
    Transform destination; // � d�finir avec l'enement OnSpawn (AISoldier ne doit pas d�pendre de GameManager)

    private void Awake()
    {
        OnSpawn = new();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>(); // retourne le premier composant actif de type T qui trouvera dans sa hiearchie
        // le parametre de GetComponentInChildren permet de prendre en compte les objets innactif (par d�faut � false).
    }

    void Start()
    {
        _animator.SetFloat("Speed", 1);
        // Utilisez la m�thode "SetDestination" du navmeshAgent
    }
}
