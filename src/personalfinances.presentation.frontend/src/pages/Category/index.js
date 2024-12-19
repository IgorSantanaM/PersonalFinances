import React, {useState} from 'react';

import {Label, Container, Select, Input, ErrorMessage} from '../../Components/Container/styles';
import {Header, Previous} from '../../Components/Header/styles';
import { GrFormPrevious} from 'react-icons/gr';
import api from '../../services/api';

export default function Category(){
    const[transactionType, setTransactionType] = useState('Income');
    const[name, setName] = useState('');
    const optionsTransaction = ['Income', 'Expense', 'Transfer', 'Loan payment', 'Loan armotization'];
    const[belongsTo, setBelongsTo] = useState('None');
    const[isValid, setIsvalid] = useState(true);
    const optionsBelongsTo = ['None', 'Salary', 'Other', 'Education', 'Food', 'Health', 'Hosehold Operations', 'Holsehold Supplies', 'Housing', 'Recreation', 'Transport', 'Utilities', 'Pets'];
    const transactionTypeIndex = transactionType.indexOf(transactionType);
    const belongsToIndex = belongsTo.indexOf(belongsTo);


    const handleBlur = () => {
        setIsvalid(name.trim() !== '');
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
    
        const data = {
          transactionType: transactionTypeIndex,
          belongsTo: belongsToIndex,
          name,
        };
    
        try {
          const response = await api.post("category/create", data);
          console.log("Data sent successfully:", response.data);
        } catch (error) {
          console.error("Error sending data:", error);
        }
      };  

    return(
        <>
        <Header>
            <Previous to="/step/category" style={{ textDecoration: 'none' }}>
                <GrFormPrevious size={25} color="black" />
            </Previous>
            <strong>Add Category</strong>
        </Header>

        <Container>
            <Label htmlFor="transactionType">Transaction Type</Label>
            
                  <Select
                  id="transactionOptions"
                  value={transactionType}
                  onChange={(e) => setTransactionType(e.target.value)}>
                    {optionsTransaction.map((optionsTransaction) => (<option 
                    key={optionsTransaction} value={optionsTransaction}>
                      {optionsTransaction}
                    </option>))}
                  </Select>

            <Label htmlFor="belongsTo">Belongs To</Label>
            <Select
                id="optionsBelongsTo"
                value={belongsTo}
                onChange={(e) => setBelongsTo(e.target.value)}>
                {optionsBelongsTo.map((optionsBelongsTo) => (<option 
                key={optionsBelongsTo} value={optionsBelongsTo}>
                {optionsBelongsTo}
            </option>))}
            </Select>

            <Label htmlFor="name">Name</Label>
            
                <Input
                    type="text"
                    id="name"
                    placeholder="Name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    onBlur={handleBlur}
                    className={`input-field ${!isValid ? 'input-error' : ''}`}
                />
                  {!isValid && <ErrorMessage>- Name is required</ErrorMessage>}

      <button onClick={handleSubmit}>Submit</button>

        </Container>
        </>
    );
}