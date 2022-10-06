import React, { useState } from 'react'
import { FaStar } from 'react-icons/fa'

const Star = ({ selected = false, onSelect = (f) => f }) => {
  return (
    <li>
      <FaStar color={selected ? 'red' : 'grey'} onClick={onSelect} />
    </li>
  )
}

function StarRating({ totalStars = 5, selectedStars = 0, onRate = (f) => f }) {
  return (
    <div>
      <div className='justify-center'>
        <ul className='flex'>
          {[...Array(totalStars)].map((_, i) => (
            <Star
              key={i}
              selected={selectedStars > i}
              onSelect={() => onRate(i + 1)}
            />
          ))}
        </ul>
        <p>
          {selectedStars} of {totalStars} starts
        </p>
      </div>
    </div>
  )
}

export default StarRating
