import stage1 from "../../../assets/img/quiet_stage_1.png";
import {NavLink, useNavigate} from "react-router-dom";
import "../css/quietstages.css"

export default function QuietTowerStage1() {
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
            <img src={stage1} alt="quiet_stage_1" />
            <NavLink to="/quiet_stage_one/hospital">
                <div className="click-zone" style={{ top: '377px', left: '463px', width: '318px', height: '110px' }} >
                </div>
            </NavLink>
        </>
    );
}