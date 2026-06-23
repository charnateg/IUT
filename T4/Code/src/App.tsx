import {NavLink, useNavigate} from "react-router-dom";
import './App.css';
import concordiaImg from './assets/img/background.png';
import {resetGameState, getGameState} from './Game/gameState.ts'

function App() {

    const navigate = useNavigate();

     function handleRestart() {
        const isSure = window.confirm("Êtes-vous sûr de vouloir recommencer ?");
        if (isSure) {
            resetGameState(); // Réinitialise l'état global
            navigate("/"); // Redirige vers le menu principal
        }
     }

    const isSportsRoomFixed = getGameState().isSportsRoomFixed;
    const isBedroomFixed = getGameState().isBedroomFixed;

    return (
        <div style={{ position: 'relative', width: '100vw', height: '100vh', overflow: 'hidden' }}>
            <button
                onClick={handleRestart}
                style={{
                    position: "absolute",
                    top: "10px",
                    left: "50%",
                    transform: "translateX(-50%)",
                    padding: "10px 20px",
                    backgroundColor: "#da0000",
                    color: "#fff",
                    border: "none",
                    borderRadius: "5px",
                    cursor: "pointer",
                }}>
                Restart
            </button>
            <img
                src={concordiaImg} 
                alt="concordia" 
                style={{ 
                    width: '100%', 
                    height: '100%', 
                    objectFit: 'cover', 
                    display: 'block' 
                }} 
            />


                <div className="missionBox">
                    <h2 className="missionTitle">Missions : </h2>
                    {!isSportsRoomFixed && !isBedroomFixed ? (
                        <div>
                            <li>Rendez-vous à la salle de sport dans la <strong>Tour Bruyante</strong>, il nous a été rapporté qu'il faisait particulièrement chaud là-bas.</li>
                            <li>Rendez-vous à la chambre dans la <strong>Tour Calme</strong>, Les hivernants se plaignent des conditions de vie dans leur chambre.</li>
                        </div>
                    ) : !isSportsRoomFixed ? (
                        <li>Rendez-vous à la salle de sport dans la <strong>Tour Bruyante</strong>, il nous a été rapporté qu'il faisait particulièrement chaud là-bas.</li>
                    ) : !isBedroomFixed ? (
                        <li>Rendez-vous à la chambre dans la <strong>Tour Calme</strong>, Les hivernants se plaignent des conditions de vie dans leur chambre.</li>
                    ) : (
                        <li>Aucune mission disponible pour le moment.</li>
                    )}
                </div>


            {/* Zones cliquables dynamiques */}
            {/* Tour de gauche : Quiet */}
                <div className="towerName" style={{ top: '360px', left: '379px', width: '507px', height: '140px' }} >
                    <h2>Tour Calme</h2>
                </div>
            <NavLink to="/quiet_stage_three">
                <div className="click-zone" style={{ top: '548px', left: '379px', width: '507px', height: '140px' }} >
                    <h2>Etage 3</h2>
                </div>
            </NavLink>
            <NavLink to="/quiet_stage_two">
                <div className="click-zone" style={{ top: '688px', left: '379px', width: '507px', height: '140px' }} >
                    <h2>Etage 2</h2>
                </div>
            </NavLink>
            <NavLink to="/quiet_stage_one">
                <div className="click-zone" style={{ top: '828px', left: '379px', width: '507px', height: '140px' }} >
                    <h2>Etage 1</h2>
                </div>
            </NavLink>

            {/* Tour de droite : Noisy */}
            <div className="towerName" style={{ top: '280px', left: '1067px', width: '507px', height: '140px' }} >
                <h2>Tour Bruyante</h2>
            </div>
            <NavLink to="/noisy_stage_three">
                <div className="click-zone" style={{ top: '468px', left: '1067px', width: '507px', height: '140px' }} >
                    <h2>Etage 3</h2>
                </div>
            </NavLink>
            <NavLink to="/noisy_stage_two">
                <div className="click-zone" style={{ top: '608px', left: '1067px', width: '507px', height: '140px' }} >
                    <h2>Etage 2</h2>
                </div>
            </NavLink>
            <NavLink to="/noisy_stage_one">
                <div className="click-zone" style={{ top: '748px', left: '1067px', width: '507px', height: '140px' }} >
                    <h2>Etage 1</h2>
                </div>
            </NavLink>
        </div>
    );
}

export default App;
