import React from 'react'
import Color from './Color'

function ColorList({
  colors = [],
  onRemoveColor = (f) => f,
  onRateColor = (f) => f,
}) {

  if (!colors.length) return <div>No color list.</div>
  return (
    <div>
      {colors.map((color) => (
        <div>
          <Color
            key={color.id}
            {...color}
            onRemoveColor={onRemoveColor}
            onRate={onRateColor}
          />
        </div>
      ))}
    </div>
  )
}

export default ColorList
