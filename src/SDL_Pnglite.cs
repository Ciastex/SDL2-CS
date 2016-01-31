using System;
using System.Runtime.InteropServices;

namespace SDL2
{
	public static class SDL_Pnglite
	{
		
		private const string nativeLibName = "SDL_pnglite.dll";
		
		/* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_LoadPNG_RW(
			IntPtr src,
			[MarshalAs(UnmanagedType.Bool)]
			bool freesrc
		);
		
		public static IntPtr SDL_LoadPNG(string filename)
		{
			return SDL_LoadPNG_RW(SDL.INTERNAL_SDL_RWFromFile(filename, "rb"), true);
		}
		
		/* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SavePNG_RW(
			IntPtr surface,
			IntPtr dst,
			[MarshalAs(UnmanagedType.Bool)]
			bool freedst
		);
		
		public static int SDL_SavePNG(IntPtr surface, string filename)
		{
			return SDL_SavePNG_RW(surface, SDL.INTERNAL_SDL_RWFromFile(filename, "wb"), true);
		}
	}
}
