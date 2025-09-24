using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class KomunikacijaHelper : IDisposable
    {
        private readonly NetworkStream _stream;
        private readonly StreamWriter _writer;
        private readonly StreamReader _reader;
        private readonly JsonSerializerOptions _json = new() { WriteIndented = false };
        private readonly object _sendLock = new();
        private bool _disposed;

        public KomunikacijaHelper(Socket socket)
        {
            // ownsSocket: true -> zatvara i soket kad se dispose-uje
            _stream = new NetworkStream(socket, ownsSocket: true);
            _reader = new StreamReader(_stream, new UTF8Encoding(false), leaveOpen: true);
            _writer = new StreamWriter(_stream, new UTF8Encoding(false)) { AutoFlush = true };
        }

        public void Posalji(object poruka)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(KomunikacijaHelper));
            var json = JsonSerializer.Serialize(poruka, poruka.GetType(), _json);
            lock (_sendLock) { _writer.WriteLine(json); }
        }

        public T Primi<T>()
        {
            if (_disposed) throw new ObjectDisposedException(nameof(KomunikacijaHelper));
            var line = _reader.ReadLine();
            if (line is null) throw new IOException("Veza je zatvorena.");
            return JsonSerializer.Deserialize<T>(line, _json)!;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            try { _writer.Dispose(); } catch { }
            try { _reader.Dispose(); } catch { }
            try { _stream.Dispose(); } catch { }
        }

        // Korisno kad u Response.Data dobiješ JsonElement:
        public static T ReadType<T>(object o)
        {
            if (o is JsonElement je) return JsonSerializer.Deserialize<T>(je.GetRawText())!;
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(o))!;
        }
    }

}
