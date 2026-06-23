import stage3 from '../../../assets/img/quiet_stage_3.png'
import {NavLink, useNavigate} from "react-router-dom";

export default function QuietTowerStage3() {
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
                    left: "55%",
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
            <img src={stage3} alt="quiet_stage_3"/>
            <NavLink to="/quiet_stage_three/laboratories">
                <div className="click-zone" style={{ top: '269px', left: '291px', width: '318px', height: '110px' }} >
                </div>
            </NavLink>
        </>
    );
}