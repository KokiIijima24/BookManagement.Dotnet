import React, { useReducer } from 'react'

function CheckBox() {
  const [checked, toggle] = useReducer((checked) => !checked, false)
  return (
    <div>
      CheckBox
      <input type='checkbox' value={checked} onChange={toggle} />
      <p>{checked ? 'checked' : 'not checked'}</p>
    </div>
  )
}

export default CheckBox
