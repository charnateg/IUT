import { createContext, useContext, useRef } from "react";

const MusicContext = createContext<{ playMusic: () => void } | null>(null);

export function MusicProvider({ children }: { children: React.ReactNode }) {
    const audioRef = useRef<HTMLAudioElement | null>(null);

    const playMusic = () => {
        if (audioRef.current) {
            audioRef.current.play().catch((err) => console.error("Failed to play audio:", err));
        }
    };

    return (
        <MusicContext.Provider value={{ playMusic }}>
            {children}
            <audio ref={audioRef} src="../assets/sound/background_music.wav" loop />
        </MusicContext.Provider>
    );
}

export function useMusic() {
    const context = useContext(MusicContext);
    if (!context) {
        throw new Error("useMusic must be used within a MusicProvider");
    }
    return context;
}