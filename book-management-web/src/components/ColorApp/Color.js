import React from 'react'
import StarRating from '../Utils/StarRating'
import { FaTrash } from 'react-icons/fa'

function Color({
  title,
  color,
  rating,
  onRemove = (f) => f,
  onRate = (f) => f,
}) {
  return (
    <div>
      <h1>{title}</h1>
      <button onClick={() => onRemove(id)}>
        <FaTrash />
      </button>
      <div style={{ height: 50, backgroundColor: color }}></div>
      <StarRating
        selectedStars={rating}
        onrate={(rating) => onRate(id, rating)}
      />
    </div>
  )
}

export default Color
