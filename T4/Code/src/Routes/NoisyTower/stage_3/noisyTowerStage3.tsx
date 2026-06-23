import etage3 from '../../../assets/img/noisy_stage_3.png';
import {useNavigate} from "react-router-dom";

export default function NoisyTowerStage3() {
    const navigate = useNavigate();

    function handleGoBack() {
        navigate("/base");
    }

    return (
        <>
            <button
                onClick={handleGoBack}
                style={{
                    position: "absolute",
                    top: "10px",
                    left: "45%",
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
            <img src={etage3} alt="noisy_stage_3"/>
            {/*<NavLink to="/noisy_stage_three/gamesroom">*/}
            {/*    <div className="click-zone" style={{ top: '813px', left: '189px', width: '214px', height: '90px' }} >*/}
            {/*    </div>*/}
            {/*</NavLink>*/}
        </>
    )
}