using System;
using static Sokol.sokol_gfx;

namespace Sokol
{
    public sealed class SgBindings
    {
        private sg_bindings _bindings;

        public SgBindings()
        {
        }

        public unsafe void SetVertexBuffer(SgBuffer buffer, int bufferIndex = 0)
        {
            if (buffer.Handle.id == 0)
            {
                throw new ArgumentException(nameof(buffer));
            }
            
            if (bufferIndex > SG_MAX_SHADERSTAGE_BUFFERS)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferIndex), bufferIndex, null);
            }
            
            _bindings.vertex_buffers[bufferIndex] = buffer.Handle;
            _bindings.vertex_buffer_offsets[bufferIndex] = 0;
        }

        public unsafe void SetVertexBufferOffset(int bufferIndex, int bufferOffset)
        {
            if (bufferIndex > SG_MAX_SHADERSTAGE_BUFFERS)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferIndex), bufferIndex, null);
            }
            
            _bindings.vertex_buffer_offsets[bufferIndex] = bufferOffset;
        }

        public void SetIndexBuffer(SgBuffer buffer)
        {
            if (buffer.Handle.id == 0)
            {
                throw new ArgumentException(nameof(buffer));
            }
            
            _bindings.index_buffer = buffer.Handle;
            _bindings.index_buffer_offset = 0;
        }
        
        public void SetIndexBufferOffset(int bufferOffset)
        {
            _bindings.index_buffer_offset = bufferOffset;
        }

        public void Apply()
        {
            sg_apply_bindings(ref _bindings);
        }
    }
}