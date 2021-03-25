using UnityEngine;

namespace KartGame.KartSystems {
public class TouchInput : BaseInput
{   public float valY=0;
    public float valX=0;

    public override Vector2 GenerateInput() {
            Vector2 vector = new Vector2 {
                x = valX,
                y = valY
            };       
            return vector;             
    }
}
}
