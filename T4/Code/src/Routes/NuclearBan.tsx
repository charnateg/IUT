import { useNavigate } from "react-router-dom";
import {resetGameState} from "../Game/gameState.ts";

export default function NuclearBan() {
    const navigate = useNavigate();

    function handleRestart() {
        const isSure = window.confirm("Êtes-vous sûr de vouloir recommencer ?");
        if (isSure) {
            resetGameState(); // Réinitialise l'état global
            navigate("/"); // Redirige vers le menu principal
        }
    }

    return (
        <div style={{position:"absolute", flexDirection:"column", alignItems:"center", justifyContent:"center", textAlign: "center", padding: "20px", marginLeft:"21%",marginRight:"21%", top:"35%" }}>
            <h1>🚫 Nucléaire Interdit !</h1>
            <p>
                L'utilisation de matériaux nucléaires est strictement interdite en Antarctique.
                La base a reçu une amende de 400 millions d'euros pour cette infraction.
            </p>
            <button
                onClick={handleRestart}
                style={{
                    marginTop: "20px",
                    padding: "10px 20px",
                    backgroundColor: "#007BFF",
                    color: "#fff",
                    border: "none",
                    borderRadius: "5px",
                    cursor: "pointer",
                    width: "200px",
                }}
            >
                Retour à l'accueil
            </button>
        </div>
    );
}