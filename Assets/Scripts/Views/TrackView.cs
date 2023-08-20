using Core.Abstracts;
using UnityEngine;
using UnityEngine.U2D;

namespace Views
{
    public class TrackView : View
    {
        [SerializeField] private SpriteShapeController spriteShapeController;
        [SerializeField] private Transform vehicleSpawnTransform;

        private Vector3 _lastPos;

        public Transform VehicleSpawnTransform => vehicleSpawnTransform;

        public void SetupTrack(int levelLength, float xMultiplier, float yMultiplier, float noiseStep,
            float curveSmoothness, float bottom)
        {
            spriteShapeController.spline.Clear();

            for (var i = 0; i < levelLength; i++)
            {
                _lastPos = transform.position +
                           new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
                spriteShapeController.spline.InsertPointAt(i, _lastPos);

                if (i != 0 && i != levelLength - 1)
                {
                    spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                    spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                    spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
                }
            }

            var position = transform.position;

            spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(_lastPos.x, position.y - bottom));
            spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(position.x, position.y - bottom));
        }
    }
}