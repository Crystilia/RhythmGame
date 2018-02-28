using UnityEngine;

[ExecuteInEditMode]
public class Post : MonoBehaviour
{

    public Material EffectMat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, EffectMat);
    }
}