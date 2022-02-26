using UnityEngine;

namespace Scripts.Interfaces
{
    public delegate void ObjectDetecteHandler(GameObject source, GameObject detectedObject);
    public interface IDetector
    {
        event ObjectDetecteHandler OnGameObjectDetectedEvent;
        event ObjectDetecteHandler OnGameObjectDetectedReleasedEvent;

        void Detect(IDetectableObject detectableObject);
        void Detect(GameObject detectedObject);
    }
}