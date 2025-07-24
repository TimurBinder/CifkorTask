using System;
using UnityEngine.Networking;

namespace CifkorTask.Model
{
    public abstract class Requester
    {
        private RequestPool _requestPool;

        public Requester(RequestPool requestPool)
        {
            _requestPool = requestPool;
        }

        public void AddRequest(string url)
        {
            UnityWebRequest request = new UnityWebRequest(url);
            _requestPool.PutRequest(request, OnCompleteResponse, OnFailedResponse);
        }

        protected abstract void OnCompleteResponse(UnityWebRequest request);

        protected abstract void OnFailedResponse(UnityWebRequest request);
    }
}