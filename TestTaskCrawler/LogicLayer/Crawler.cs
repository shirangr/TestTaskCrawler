using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskCrawler.LogicLayer
{
    public class Downloader
    {
        private readonly HttpClient _httpClient;

        public Downloader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<IResponse> DownloadHtmlPage(Uri url, CancellationToken cancellationToken)
        //{
        //    using (var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
        //    {
        //        if (response.Content.Headers.ContentType.MediaType == "text/html")
        //        {
        //            var text = await response.Content.ReadAsStringAsync();

        //            return VirtualResponse.Create(r => r
        //               .Content(text)
        //               .Address(url)
        //               .Status(HttpStatusCode.OK));
        //        }
        //    }
        //    return null;
        //}
    }

    public class WebCrawler
    {
        //private readonly Downloader _downloader;
        //private readonly ConcurrentQueue<Uri> _queue;
        //private readonly ISet<Uri> _seen;
        //private readonly string _validHost;

        //private static readonly IConfiguration _configuration = Configuration.Default
        //        .SetCulture(CultureInfo.InvariantCulture)
        //        .WithDefaultLoader(x => {
        //            x.IsNavigationEnabled = false;
        //            x.IsResourceLoadingEnabled = false;
        //        })
        //    ;

        //public WebCrawler(Downloader downloader, Uri url)
        //{
        //    _downloader = downloader;
        //    _queue = new ConcurrentQueue<Uri>();
        //    _seen = new HashSet<Uri>();
        //    _validHost = url.Host;
        //    Enqueue(url);
        //}

        //public async Task Run(int maxTasks = 5, CancellationToken cancellationToken = default)
        //{
        //    var tasks = new HashSet<Task> {
        //        TryProcessQueue( cancellationToken )
        //    };

        //    void AddProcessTask()
        //    {
        //        var task = TryProcessQueue(cancellationToken);
        //        if (task != null)
        //        {
        //            tasks.Add(task);
        //        }
        //    }

        //    async Task WaitForTaskCompletion()
        //    {
        //        var completedTask = await Task.WhenAny(tasks);
        //        tasks.Remove(completedTask);
        //    }


        //    while (tasks.Count > 0 && !cancellationToken.IsCancellationRequested)
        //    {
        //        try
        //        {
        //            await WaitForTaskCompletion();
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            return;
        //        }

        //        AddProcessTask();
        //        if (_queue.Count > maxTasks && tasks.Count < maxTasks)
        //        {
        //            //Console.WriteLine(Colorize($" * {DarkMagenta}Adding worker{Gray}"));
        //            AddProcessTask();
        //        }
        //    }
        //}

        //private Task TryProcessQueue(CancellationToken cancellationToken)
        //{
        //    if (_queue.TryDequeue(out var url))
        //    {
        //        return ProcessUrl(url, cancellationToken);
        //    }

        //    return null;
        //}

        //private void Enqueue(Uri url)
        //{
        //    if (url.Scheme != "https" || url.Scheme == "http")
        //    {
        //        return;
        //    }

        //    if (url.Host != _validHost)
        //    {
        //        return;
        //    }

        //    if (_seen.Add(url))
        //    {
        //        //Console.WriteLine(Colorize($" * {DarkCyan}Found {Cyan}{url}{Gray}"));
        //        _queue.Enqueue(url);
        //    }
        //}

        //private async Task ProcessUrl(Uri url, CancellationToken cancellationToken)
        //{
        //    //Console.WriteLine(Colorize($"{DarkCyan}Downloading {Yellow}{url}{Gray}"));
        //    var response = await _downloader.DownloadHtmlPage(url, cancellationToken);
        //    if (response == null)
        //    {
        //        return;
        //    }

        //    var document = await ParseDocument(response, cancellationToken);

        //    foreach (var x in document.All.OfType<IUrlUtilities>().Where(x => !string.IsNullOrEmpty(x.Href)))
        //    {
        //        var href = WithoutHash(x.Href);

        //        if (!string.IsNullOrEmpty(href))
        //        {
        //            Enqueue(new Uri(url, href));
        //        }
        //    }
        //}

        //private static async Task<IDocument> ParseDocument(IResponse response, CancellationToken cancellationToken)
        //{
        //    var browsingContext = BrowsingContext.New(_configuration);
        //    var createDocumentOptions = new CreateDocumentOptions(response, _configuration);
        //    var document = await new DocumentFactory().CreateAsync(browsingContext, createDocumentOptions, cancellationToken);
        //    return document;
        //}

        //private static string WithoutHash(string href)
        //{
        //    var hashIndex = href.IndexOf('#');
        //    if (hashIndex != -1)
        //    {
        //        href = href.Substring(0, hashIndex);
        //    }
        //    return href;
        //}
    }

}
