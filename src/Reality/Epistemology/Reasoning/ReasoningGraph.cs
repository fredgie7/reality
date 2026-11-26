using System.Collections.ObjectModel;

namespace Reality.Epistemology.Reasoning;

/// <summary>
/// A directed, inspectable graph of epistemic claims and their stated relationships.
/// No edge amounts to proof, and graph reachability is not a confidence score.
/// </summary>
public sealed class ReasoningGraph
{
    private readonly ReadOnlyCollection<ReasoningNode> _nodes;
    private readonly ReadOnlyCollection<ReasoningConnection> _connections;
    private readonly Dictionary<string, ReasoningNode> _index;

    public ReasoningGraph(IEnumerable<ReasoningNode> nodes, IEnumerable<ReasoningConnection> connections)
    {
        ArgumentNullException.ThrowIfNull(nodes);
        ArgumentNullException.ThrowIfNull(connections);

        _nodes = Array.AsReadOnly(nodes.ToArray());
        _connections = Array.AsReadOnly(connections.ToArray());
        _index = new Dictionary<string, ReasoningNode>(StringComparer.Ordinal);

        foreach (var node in _nodes)
        {
            ArgumentNullException.ThrowIfNull(node);
            if (string.IsNullOrWhiteSpace(node.Id) || string.IsNullOrWhiteSpace(node.Description))
                throw new ArgumentException("Every node needs a nonempty ID and description.", nameof(nodes));
            if (!_index.TryAdd(node.Id, node))
                throw new ArgumentException($"Duplicate reasoning node ID: {node.Id}.", nameof(nodes));
            if (node.SourceUrl is not null && (!Uri.TryCreate(node.SourceUrl, UriKind.Absolute, out var source) || (source.Scheme != Uri.UriSchemeHttps && source.Scheme != Uri.UriSchemeHttp)))
                throw new ArgumentException($"Node '{node.Id}' has an invalid source URL.", nameof(nodes));
        }

        foreach (var connection in _connections)
        {
            ArgumentNullException.ThrowIfNull(connection);
            if (!_index.ContainsKey(connection.FromId) || !_index.ContainsKey(connection.ToId))
                throw new ArgumentException($"Connection '{connection.FromId}' to '{connection.ToId}' references an unknown node.", nameof(connections));
            if (string.IsNullOrWhiteSpace(connection.Justification))
                throw new ArgumentException("Every connection requires a justification.", nameof(connections));
        }
    }

    public IReadOnlyList<ReasoningNode> Nodes => _nodes;
    public IReadOnlyList<ReasoningConnection> Connections => _connections;

    public ReasoningNode GetNode(string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return _index.TryGetValue(id, out var node) ? node : throw new KeyNotFoundException($"Unknown reasoning node: {id}.");
    }

    public IReadOnlyList<ReasoningConnection> Incoming(string id)
    {
        GetNode(id);
        return _connections.Where(link => link.ToId == id).ToArray();
    }

    /// <summary>
    /// Follow every incoming connection, recursively, toward upstream premises and sources.
    /// Handles cycles and shared ancestors without infinite recursion or duplicated links.
    /// </summary>
    public IReadOnlyList<ReasoningConnection> TraceReasons(string id)
    {
        GetNode(id);
        var visited = new HashSet<string>(StringComparer.Ordinal) { id };
        var queue = new Queue<string>();
        var result = new List<ReasoningConnection>();
        queue.Enqueue(id);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var link in _connections.Where(item => item.ToId == current))
            {
                result.Add(link);
                if (visited.Add(link.FromId))
                    queue.Enqueue(link.FromId);
            }
        }

        return result;
    }
}
