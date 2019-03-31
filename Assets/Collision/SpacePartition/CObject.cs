using LockStepMath;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static LockStepMath.LMath;
using Point = LockStepMath.LVector;
using Point2D = LockStepMath.LVector2D;
using static LockStepCollision.Collision;
using Debug = UnityEngine.Debug;
using Shape = LockStepCollision.BaseShape;
using static LockStep.Algorithm;

namespace LockStepCollision {
    /// <summary>
    /// Collision Object
    /// </summary>
    public partial class CObject {
        public int ID { private set; get; }
        public CObject pNextObject; // Embedded link to next hgrid object
        public CObject pPreObject;
        public Point pos; // x, y (and z) position for sphere (or top left AABB corner)
        public LFloat radius; // Radius for bounding sphere (or width of AABB)
        public int bucket; // Index of hash bucket object is in
        public int level; // Grid level for the object
        public Cell cellPos; // which cell it belong to
        public byte layerMaskIdx;//layer mask for speed up collision detection
        public uint LayerMask {
            get { return 1u << (layerMaskIdx + 1); }
        }

        public CObject(int layerMaskIdx){
            ID = ++SID;
            if (SID == int.MaxValue) {
                SID = 0;
            }
            this.layerMaskIdx = (byte)layerMaskIdx;
        }

        private static int SID = 0;

        public override int GetHashCode(){
            return ID;
        }
    }
}