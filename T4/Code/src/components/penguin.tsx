import { useEffect, useState } from "react";
import penguin1 from "../assets/img/manchot/penguin_walk01.png";
import penguin2 from "../assets/img/manchot/penguin_walk02.png";
import penguin3 from "../assets/img/manchot/penguin_walk03.png";
import penguin4 from "../assets/img/manchot/penguin_walk04.png";

const penguinFrames = [penguin1, penguin2, penguin3, penguin4];

export default function Penguin() {
    const [position, setPosition] = useState(0); // Position horizontale
    const [frameIndex, setFrameIndex] = useState(0); // Index de l'image actuelle
    const [direction, setDirection] = useState(1); // Direction (1 = droite, -1 = gauche)
    const [isVisible, setIsVisible] = useState(true); // Visibilité du manchot

    useEffect(() => {
        if (!isVisible) {
            const timeout = setTimeout(() => {
                setPosition(direction === 1 ? 0 : window.innerWidth - 100); // Réinitialise la position
                setIsVisible(true); // Réaffiche le manchot
            }, Math.random() * 2000 + 1000); // Temps aléatoire entre 1 et 3 secondes
            return () => clearTimeout(timeout);
        }

        const interval = setInterval(() => {
            setPosition((prev) => {
                const newPos = prev + direction * 5; // Déplace le manchot de 5px
                if (newPos > window.innerWidth - 100 || newPos < 0) {
                    setIsVisible(false); // Cache le manchot
                    setDirection((prevDir) => -prevDir); // Change de direction
                }
                return newPos;
            });

            setFrameIndex((prev) => (prev + 1) % penguinFrames.length); // Change l'image pour l'animation
        }, 100); // Change toutes les 100ms

        return () => clearInterval(interval);
    }, [direction, isVisible]);

    if (!isVisible) return null;

    return (
        <img
            src={penguinFrames[frameIndex]}
            alt="Penguin"
            style={{
                position: "absolute",
                bottom: "50px", // Position verticale fixe
                left: `${position}px`, // Position horizontale dynamique
                height: "100px",
                transition: "left 0.1s linear",
                transform: direction === 1 ? "scaleX(1)" : "scaleX(-1)", // Inverse l'image selon la direction
                zIndex: 1000, // Assure que le manchot est au premier plan
                pointerEvents: "none", // Empêche l'interaction avec le manchot
            }}
        />
    );
}