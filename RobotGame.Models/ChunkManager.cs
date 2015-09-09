using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotGame.Models
{
    public class ChunkManager : IEnumerable<Chunk>
    {
        private List<Chunk> loadedChunks;

        public ChunkManager(ISaveLoad saveload, IGenerator generator)
        {
            SaveLoad = saveload;
            Generator = generator;

            loadedChunks = new List<Chunk>();
        }

        public Chunk this[int x, int z]
        {
            get
            {
                Chunk c;
                if(!IsLoaded(x, z, out c))
                {
                    c = Load(x, z);
                }
                return c;
            }
        }

        public Chunk Load(int x, int z)
        {
            lock (loadedChunks)
            {
                Chunk c;
                if(!IsLoaded(x, z, out c))
                {
                    c = SaveLoad.LoadChunk(x, z);
                    if(c == null)
                    {
                        c = Generator.Generate(this, x, z);
                    }
                    loadedChunks.Add(c);
                    return c;
                }
                return c;
            }
        }

        public void Unload(int x, int z)
        {
            lock (loadedChunks)
            {
                Chunk c;
                if (IsLoaded(x, z, out c))
                {
                    SaveLoad.SaveChunk(c);
                    loadedChunks.Remove(c);
                }
            }
        }

        public void UnloadAll()
        {
            lock (loadedChunks)
            {
                foreach(var c in loadedChunks)
                {
                    SaveLoad.SaveChunk(c);
                }
                loadedChunks.Clear();
            }
        }

        public bool IsLoaded(int x, int z)
        {
            Chunk c;
            return IsLoaded(x, z, out c);
        }

        public bool IsLoaded(int x, int z, out Chunk chunk)
        {
            lock (loadedChunks)
            {
                chunk = loadedChunks
                    .SingleOrDefault(o => o.X == x && o.Z == z);
                return chunk != null;
            }
        }

        public void Tick()
        {
            lock(loadedChunks)
            {
                foreach(var c in loadedChunks)
                {
                    c.Tick();
                }
            }
        }

        public IGenerator Generator { get; private set; }

        public ISaveLoad SaveLoad { get; private set; }

        public IEnumerator<Chunk> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}