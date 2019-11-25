using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace MFLReskin.Models
{
    public class Players
    {
        private List<Player> _allPlayers;
        private IndexedDBManager _dbManager;

        public static async Task<Players> CreateAsync(IndexedDBManager dbManager)
        {
            var players = new Players(dbManager);
            await players.InitializeAsync();
            return players;
        }
        private Players(IndexedDBManager dbManager)
        {
            _dbManager = dbManager;
        }
        private async Task InitializeAsync()
        {
            _allPlayers = await _dbManager.GetRecords<Player>("Players");
        }

        public async void AddPlayer(Player player)
        {
            var record = new StoreRecord<Player>
            {
                Storename = "Players",
                Data = player
            };

            await _dbManager.AddRecord(record);
            _allPlayers.Add(player);
        }

        public void AddPlayers(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                AddPlayer(player);
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _allPlayers;
        }

        public IEnumerable<Player> GetPlayersByIds(IEnumerable<int> ids)
        {
            var players = new List<Player>();

            ids.Select(id => GetPlayerById(id)).Where(x => x != null);

            return players;
        }

        public Player GetPlayerById(int id)
        {
            var player = _allPlayers.Find(x => x.Id == id);

            if (player == null) return null;
            
            return player;
        }

        public async void RemovePlayer(Player player)
        {
            var existingPlayer = _allPlayers.Find(x => x.Id == player.Id);

            if (existingPlayer == null) return;

            await _dbManager.DeleteRecord("Players", player.Id);
            _allPlayers.Remove(existingPlayer);
        }

        public async void UpdatePlayer(Player player)
        {
            var existingPlayer = _allPlayers.Find(x => x.Id == player.Id);

            if (existingPlayer == null)
            {
                AddPlayer(player);
                return;
            }

            var record = new StoreRecord<Player>
            {
                Storename = "Players",
                Data = player
            };

            await _dbManager.UpdateRecord(record);

            PropertyInfo[] properties = typeof(Player).GetProperties();

            foreach (var prop in properties)
            {
                if (prop.GetValue(existingPlayer) != prop.GetValue(player))
                {
                    prop.SetValue(existingPlayer, prop.GetValue(player));
                }
            }

            _allPlayers.Remove(existingPlayer);
        }

        public void UpdatePlayers(IEnumerable<Player> players)
        {
            foreach(var player in players)
            {
                UpdatePlayer(player);
            }
        }
    }
}
