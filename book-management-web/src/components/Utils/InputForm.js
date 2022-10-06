import React from 'react'

const InputField = ({ value, label, name, placeholder, type, onChange }) => (
  <div className='form-group'>
    {label && (
      <label
        htmlFor={name}
        className='block text-grey-darker text-sm font-bold mb-2'
      >
        {label}
      </label>
    )}
    <input
      className='shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker'
      type={type}
      id={name}
      value={value}
      name={name}
      placeholder={placeholder}
      onChange={onChange}
    />
  </div>
)

export default InputField
