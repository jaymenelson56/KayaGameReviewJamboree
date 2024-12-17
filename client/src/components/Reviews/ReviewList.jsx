import { useEffect, useState } from "react"
import "./Review.css"
import { Link, useNavigate } from "react-router-dom"
import { getReviewList } from "../../managers/reviewManager"


export const ReviewList = () => {
    const [reviews, setReviews] = useState([])
    const navigate = useNavigate()
    useEffect(() => {
        getReviewList().then((reviewsArray) =>
            setReviews(reviewsArray))
    }, [])
    return (
        <div className="review-block">
            <header className="list-block"><h2>All Reviews</h2>
            <button className="btn" onClick={() => {
                navigate("/reviews/create")
            }}>Create New Review</button>
            </header>
            
            <ul className="list-block">
                {reviews.map((review) => {
                    return (<li key={review.id}>
                        <span className="title"><Link to={`/reviews/${review.id}`}>{review.title}</Link></span>
                        <span> by </span>
                        <span className="name">{review.userName}</span>
                    </li>)
                })}
            </ul>
        </div>
    )
}