using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.Networking;

public class RequestPool
{
    private Queue<RequestItem> _queue;
    private bool _isProcessing = false;
    private int _millisecondsDelay;
    private CancellationTokenSource _cancellationTokenSource;

    public RequestPool(int millisecondsDelay)
    {
        _millisecondsDelay = millisecondsDelay;
        _queue = new Queue<RequestItem>();
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public async UniTask PutRequest(
        UnityWebRequest request,
        Action<UnityWebRequest> onComplete = null,
        Action<UnityWebRequest> onError = null
        )
    {
        RequestItem item = new RequestItem(request, onComplete, onError);
        _queue.Enqueue(item);

        if (_isProcessing == false)
            await ProcessQueue();
    }

    public void ClearQueue()
    {
        while (_queue.Count > 0)
        {
            RequestItem item = _queue.Dequeue();
            item.Request?.Dispose();
        }

        _isProcessing = false;
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }

    private async UniTask ProcessQueue()
    {
        _isProcessing = true;

        while (_queue.Count > 0)
        {
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            await ProcessItem(_queue.Dequeue(), cancellationToken);
            await UniTask.Delay(_millisecondsDelay, cancellationToken: cancellationToken);
        }

        _isProcessing = false;
    }

    private async UniTask ProcessItem(RequestItem item, CancellationToken cancellationToken)
    {
        await item.Request.SendWebRequest().ToUniTask(cancellationToken: cancellationToken);

        if (item.Request.result == UnityWebRequest.Result.Success)
            item.OnComplete?.Invoke(item.Request);
        else
            item.OnError?.Invoke(item.Request);

        item.Request.Dispose();
    }

    private class RequestItem
    {
        public UnityWebRequest Request { get; }
        public Action<UnityWebRequest> OnComplete { get; }
        public Action<UnityWebRequest> OnError { get; }

        public RequestItem(
            UnityWebRequest request,
            Action<UnityWebRequest> onComplete,
            Action<UnityWebRequest> onError
            )
        {
            Request = request;
            OnComplete = onComplete;
            OnError = onError;
        }
    }
}

