using UnityEngine;

namespace StackJump.Brick
{
    // Provides generic factory for generating objects
    public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T spawnedObject;
        [Tooltip("Transform where do we store the created objects")]
        [SerializeField] private Transform spawnedObjectsContainer; 

        public T InstantiateObject(Transform spawnerTransform)
        {
            return Instantiate(spawnedObject, spawnerTransform.position, Quaternion.identity, spawnedObjectsContainer);
        }
    }
}