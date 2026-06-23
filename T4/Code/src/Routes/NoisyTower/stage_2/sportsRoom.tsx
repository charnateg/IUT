import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
    addThermostatToRoom,
    setSportsRoomFix,
    hasBeenUsed,
    hasItemInInventory,
    isItemUsable,
    isThermostatAddedToRoom,
    isDialogueSportRoomReaded,
    isSportRoomWindowClosedOnce,
    sportRoomWindowClosed,
    isSportsRoomFix, dialogueSportRoomRead,
} from "../../../Game/gameState.ts";
import dinnerbone from "../../../assets/img/dinnerbone.png";
import muscuImg from "../../../assets/img/muscu.png";
import muscuFermeImg from "../../../assets/img/muscu_ferme.png";
import pnj from "../../../assets/img/pnj.png";

export default function SportsRoom() {
    const [isWindowOpen, setIsWindowOpen] = useState(!isThermostatAddedToRoom());
    const [isThermostatPlaced, setIsThermostatPlaced] = useState(isThermostatAddedToRoom());
    const [isDialogueReaded, setDialogue] = useState(isDialogueSportRoomReaded());
    const navigate = useNavigate();

    function handlePlaceThermostat() {
        if (hasItemInInventory(1) && isItemUsable(1)) {
            hasBeenUsed(1);
            addThermostatToRoom();
            setIsThermostatPlaced(true);
            setIsWindowOpen(false); // Ferme la fenêtre définitivement
            setSportsRoomFix(true);
            console.log(isSportsRoomFix());
        } else {
            alert("Vous n'avez pas de thermostat dans votre inventaire !");
        }
    }

    function handleDialogue() {
        if (isDialogueReaded && hasItemInInventory(1) && isItemUsable(1)) {
            alert("Un thermostat pile quand j'en demande un ? Si on avait su, moi et la team on aurait demandé plus tôt !")
            handlePlaceThermostat();
        } else if (isThermostatPlaced) {
            alert("Encore merci pour ce thermostat, on peux enfin faire du sport sans que le froid extérieur risque de détruire l'équipement !")
        } else if (isSportRoomWindowClosedOnce()) {
            alert("Tu va pas refermer la fenêtre hein ?");
        } else {
            alert("Tu veux la machine ? Désolé mais je suis qu'au début de ma série...")
        }
    }

    function handleCloseWindow() {
        if (!isThermostatPlaced) {
            alert("Ne ferme pas la fenêtre, à cause des groupes électrogènes, la chaleur ici est insupportable. Je te laisse imaginer si en plus on fait du sport ! Il faudrait éventuellement un thermostat mais ça ne court pas les rues... Reviens vers moi si tu as une solution.");
            setDialogue(true);
            dialogueSportRoomRead();
            sportRoomWindowClosed();
            setIsWindowOpen(false); // Ferme temporairement la fenêtre
            setTimeout(() => {
                // Vérifie si le thermostat n'est toujours pas placé avant de réouvrir la fenêtre
                if (!isThermostatAddedToRoom()) {
                    setIsWindowOpen(true); // Réouvre la fenêtre uniquement si le thermostat n'est pas placé
                }
            }, 5000);
        }
    }

    function handleGoBack() {
        navigate("/noisy_stage_two");
    }

    return (
        <div style={{ position: "relative", width: "100vw", height: "100vh", overflow: "hidden" }}>
            <img
                src={isWindowOpen ? muscuImg : muscuFermeImg} // Affiche muscu_ferme.png si thermostat placé
                alt={isWindowOpen ? "Open Window" : "Closed Window"}
                style={{
                    width: "100%",
                    height: "100%",
                    objectFit: "cover",
                }}
            />
            <img
                src={pnj}
                alt="PNJ"
                style={{
                    cursor: 'pointer',
                    position: "absolute",
                    bottom: "20%", // Position verticale fixe
                    left: "33%", // Position horizontale dynamique
                    transform: "rotate(210deg) scaleX(-1)",
                    height: "36%",
                    zIndex: 1000, // Assure que le manchot est au premier plan
                }}
                onClick={handleDialogue}
            />
            <img
                src={dinnerbone}
                alt="PNJ"
                style={{
                    position: "absolute",
                    bottom: "13%", // Position verticale fixe
                    left: "23%", // Position horizontale dynamique
                    transform: "rotate(210deg) ",
                    height: "6%",
                    zIndex: 1000, // Assure que le manchot est au premier plan
                }}
            />
            {isWindowOpen && !isThermostatPlaced && (
                <button
                    onClick={handleCloseWindow}
                    style={{
                        position: "absolute",
                        top: "50%",
                        left: "10%", // Bouton à gauche
                        transform: "translateY(-50%)",
                        padding: "10px 20px",
                        backgroundColor: "#FF5733",
                        color: "#fff",
                        border: "none",
                        borderRadius: "5px",
                        cursor: "pointer",
                    }}
                >
                    Fermer la fenêtre
                </button>
            )}
            <button
                onClick={handleGoBack}
                style={{
                    position: "absolute",
                    top: "10px",
                    left: "50%",
                    transform: "translateX(-50%)",
                    padding: "10px 20px",
                    backgroundColor: "#28A745",
                    color: "#fff",
                    border: "none",
                    borderRadius: "5px",
                    cursor: "pointer",
                }}>
                Retour
            </button>
        </div>
    );
}
