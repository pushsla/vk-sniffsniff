using VkNet;
using VkNet.Abstractions;

namespace sniff
{
    public interface IVkApiApp : IVkApi { }
    public interface IVkApiGroup : IVkApi { }

    public class VkApiApp : VkApi, IVkApiApp { }
    public class VkApiGroup : VkApi, IVkApiGroup { }
}