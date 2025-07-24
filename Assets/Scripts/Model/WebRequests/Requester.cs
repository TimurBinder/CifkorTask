using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace CifkorTask.Model
{
    public abstract class Requester
    {
        protected RequestPool RequestPool;

        public Requester(RequestPool requestPool)
        {
            RequestPool = requestPool;
        }

        public virtual async UniTaskVoid AddRequest(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            await RequestPool.PutRequest(request, OnCompleteResponse, OnFailedResponse);
        }

        protected abstract void OnCompleteResponse(UnityWebRequest request);

        protected abstract void OnFailedResponse(UnityWebRequest request);
    }
}