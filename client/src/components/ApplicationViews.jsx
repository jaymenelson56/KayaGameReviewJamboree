import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./Home/Home";
import { About } from "./About/About";
import { ReviewList } from "./Reviews/ReviewList";
import { Review } from "./Reviews/Review";
import { CreateReview } from "./Reviews/CreateReview";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route path="/About">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <About />
              </AuthorizedRoute>
            }
          />
        </Route>
      </Route>
      <Route path="Reviews">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ReviewList />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":reviewId"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Review loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="create"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateReview loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
