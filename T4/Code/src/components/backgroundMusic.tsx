import { useEffect, useRef } from "react";

export default function BackgroundMusic() {
    const audioRef = useRef<HTMLAudioElement | null>(null);

    useEffect(() => {
        const audio = audioRef.current;
        if (audio) {
            audio.loop = true; // Active la lecture en boucle
            audio.volume = 1; // Ajuste le volume (0.0 à 1.0)
            audio.play().catch((err) => console.error("Failed to play audio:", err));
        }
    }, []);

    return <audio ref={audioRef} src="../assets/sound/background_music.wav" />;
}