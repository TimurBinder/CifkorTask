using System;
using UnityEngine;
using UnityEngine.Networking;

namespace CifkorTask.Model
{
    public class ImageRequester : Requester
    {
        public event Action<Sprite> ImageLoaded;

        public ImageRequester(RequestPool requestPool) : base(requestPool)
        {}

        protected override void OnCompleteResponse(UnityWebRequest request)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            float centerPivot = 0.5f;

            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(centerPivot, centerPivot)
            );
            ImageLoaded?.Invoke(sprite);
        }

        protected override void OnFailedResponse(UnityWebRequest request)
        {
            Debug.LogError($"Image download failed: {request.error}");
        }
    }
}
