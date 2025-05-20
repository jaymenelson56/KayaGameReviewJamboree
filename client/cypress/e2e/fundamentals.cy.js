describe('Opening Test', () => {
  it('Contains correct header text', () => {
    cy.visit('/')
    cy.get('[data-test="navbar-header"]').should('contain.text', 'Kaya')
  })
})