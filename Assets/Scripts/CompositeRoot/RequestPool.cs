using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class RequestPool
{
    private Queue<RequestItem> _queue;
    private bool _isProcessing = false;
    private int _millisecondsDelay;

    public RequestPool(int millisecondsDelay)
    {
        _millisecondsDelay = millisecondsDelay;
    }

    public async Task PutRequest(
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
    }

    private async Task ProcessQueue()
    {
        _isProcessing = true;

        while (_queue.Count > 0)
        {
            RequestItem item = _queue.Peek();
            await item.Request.SendWebRequest();
            _queue.Dequeue();
            item.Request.Dispose();
            await Task.Delay(_millisecondsDelay);
        }

        _isProcessing = false;
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

