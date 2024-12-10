import { Link } from "react-router-dom";
import "./Home.css";

export const Home = () => {
  return (
    <div className="home">
      <div className="home-container">
        <h1>
          <span>Welcome to</span>
          <span>Kaya's Video Game Reviews</span>
        </h1>
        <div>
          <Link to="/reviews">Click here for reviews</Link>
        </div>
      </div>
      <div className="welcome-container">
        <h1>
          <span>Kaya Loves Games</span>
        </h1>
        <div>
          Kaya and her pals are ready to lend you a hand in choosing which video
          games deserve your precious time!
        </div>
      </div>
    </div>
  );
};
